import { Component, OnInit } from '@angular/core';
import {KupacGetallEndpoint, KupacGetAllResponseKupci} from "../../endpoints/kupac-endpoints/Kupac-getall.endpoint";
import {
  NarudzbaGetKupacEndpoint,
  NarudzbaGetKupacResponseNarudzbe
} from "../../endpoints/narudzba-endpoints/narudzbe-get-kupac.endpoint";
import { jsPDF } from 'jspdf';
import html2canvas from 'html2canvas';
import {DomSanitizer, SafeResourceUrl} from "@angular/platform-browser";
@Component({
  selector: 'app-pregled-narudzbi',
  templateUrl: './pregled-narudzbi.component.html',
  styleUrls: ['./pregled-narudzbi.component.css']
})
export class PregledNarudzbiComponent implements OnInit {

  constructor(private kupacGetallEndpoint:KupacGetallEndpoint,
              private narudzbaGetKupacEndpoint:NarudzbaGetKupacEndpoint,
              private sanitizer: DomSanitizer) { }
  kupci:KupacGetAllResponseKupci[]=[];
  kupacNarudzbe:NarudzbaGetKupacResponseNarudzbe[]=[];
  ukupnoPlaceno:number=0;
  isVidljivo:boolean=false;
  pdfSrc: SafeResourceUrl | null = null;
  sanitizedPdfSrc: SafeResourceUrl | null = null;
  odabraniKupac:any;
  ngOnInit(): void {
    this.fetchKupci();
  }
  fetchKupci(){
    this.kupacGetallEndpoint.obradi().subscribe(x=>{
      this.kupci=x.kupci
    })
  }


  pregledajNarudzbe(id:number, item:any) {
    this.isVidljivo=!this.isVidljivo
    this.narudzbaGetKupacEndpoint.obradi(id).subscribe(x=>{
      this.kupacNarudzbe=x.narudzbe
      this.ukupnoPlaceno=x.ukupnoPlaceno
      this.odabraniKupac = item;
    })
  }

  kreirajPdf() {
    console.log('PDF creation started');
    const content = document.getElementById('content'); // Ensure this ID is correct
    if (content) {
      html2canvas(content).then(canvas => {
        const imgData = canvas.toDataURL('image/png');
        const pdf = new jsPDF('p', 'mm', 'a4');
        const imgProps = pdf.getImageProperties(imgData);
        const pdfWidth = pdf.internal.pageSize.getWidth();
        const pdfHeight = (imgProps.height * pdfWidth) / imgProps.width;

        pdf.addImage(imgData, 'PNG', 0, 0, pdfWidth, pdfHeight);

        // Generate PDF as a Blob URL
        const pdfBlob = pdf.output('blob');
        const pdfUrl = URL.createObjectURL(pdfBlob);

        // Store the raw URL and sanitize it separately
        this.pdfSrc = pdfUrl;
        this.sanitizedPdfSrc = this.sanitizer.bypassSecurityTrustResourceUrl(pdfUrl);
      })
    } else {
      console.error('Content not found');
    }
  }
  todayDate = new Date();
  currentYear = new Date().getFullYear();

  openPdf() {
    if (this.pdfSrc) {
      // @ts-ignore
      window.open(this.pdfSrc, '_blank');
    }
  }
}
