import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http: HttpClient) { }
  loginUser(login:any){
    return this.http.post('http://localhost:5165/api/Login/LoginUser',login,{responseType:'text'})
  }
}
