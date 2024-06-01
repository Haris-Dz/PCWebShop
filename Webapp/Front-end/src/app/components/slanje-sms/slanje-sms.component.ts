import { Component, OnInit } from '@angular/core';
import {
  KupacGetallEndpoint,
  KupacGetAllResponse,
  KupacGetAllResponseKupci
} from "../../endpoints/kupac-endpoints/Kupac-getall.endpoint";
import {PosaljiSmsEndpoint} from "../../endpoints/sms-endpoints/posalji-sms.endpoint";
import {ErrorHandlerService} from "../../helper/error-handler.service";
@Component({
  selector: 'app-slanje-sms',
  templateUrl: './slanje-sms.component.html',
  styleUrls: ['./slanje-sms.component.css']
})
export class SlanjeSmsComponent implements OnInit {

  constructor(private kupacGetallEndpoint:KupacGetallEndpoint,
              private posaljiSmsEndpoint:PosaljiSmsEndpoint,
              private errorHandlerService:ErrorHandlerService) { }
  kupciResponse : KupacGetAllResponseKupci[]=[];
  slanjeSMS:any = null;
  ngOnInit(): void {
    this.fetchKupci();

  }
  fetchKupci(){
    this.kupacGetallEndpoint.obradi().subscribe((x:KupacGetAllResponse)=>{
      this.kupciResponse = x.kupci
  })
  }

  pripremiZaSlanje(brojmobitela:string) {
    this.slanjeSMS={
      to:brojmobitela,
      text: ""
    }
  }

  posalji() {
    this.posaljiSmsEndpoint.obradi(this.slanjeSMS).subscribe(x=>{
        alert("message sent");
        this.slanjeSMS =null;
        this.ngOnInit();
    },(error)=>{
      alert("message not sent");
    });
  }
}
