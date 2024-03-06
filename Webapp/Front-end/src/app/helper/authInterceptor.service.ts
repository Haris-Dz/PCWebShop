import {Injectable} from "@angular/core";
import {HttpHandler, HttpInterceptor, HttpRequest} from "@angular/common/http";
import {MyAuthService} from "../services/myAuthService";

@Injectable()
export class AuthInterceptor implements HttpInterceptor{

  constructor(private auth: MyAuthService) {}

  intercept(req: HttpRequest<any>, next: HttpHandler) {
    // Get the auth token from the service.
    const authToken = this.auth.getAuthorizationToken()?.vrijednostTokena??"";

    // Clone the request and replace the original headers with
    // cloned headers, updated with the authorization.
    const authReq = req.clone({
      headers: req.headers.set('my-auth-token', authToken)
    });

    // send cloned request with header to the next handler.
    return next.handle(authReq);
  }
}
