import {Injectable} from "@angular/core";
import {Observable} from "rxjs";
import {LoginObject} from "./login-object.model";
import {HttpClient} from "@angular/common/http";
import {User} from "../../models/user.model";

@Injectable()
export class AuthenticationService {

  constructor(private http: HttpClient) {}


  login(loginObj: LoginObject): Observable<User> {
    return this.http.post<User>('/Login/GetLogin' , loginObj);
  }

  logout(): Observable<Boolean> {
    return this.http.post<Boolean>('/Login/GetLogout', {});
  }
}


