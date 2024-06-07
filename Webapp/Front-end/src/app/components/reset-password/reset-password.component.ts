import { Component, OnInit } from '@angular/core';
import {ResetPasswordEndpoint} from "../../endpoints/kupac-endpoints/reset-password.endpoint";
import {Router} from "@angular/router";

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.css']
})
export class ResetPasswordComponent implements OnInit {

  constructor(private resetPasswordEndpoint:ResetPasswordEndpoint,
              public router: Router) { }

  resetrequest:any;

  ngOnInit(): void {
    this.resetrequest={
      email:""
    }
  }

  resetujpassword() {

    this.resetPasswordEndpoint.obradi(this.resetrequest).subscribe(x=>{
      alert("Password resetovan");
      this.router.navigate(['/home']);

    },error => {
      alert("Pogresan Email")
    })
  }
}
