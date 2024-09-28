import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Login } from '../Models/login.model';
import { Globals } from '../common/globals';


@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  Login(data: Login){
    return this.http.post(Globals.apiUrl + '/Users/Login', data);
  }

  GetAllUsers(){
    return this.http.get(Globals.apiUrl + '/Users/GetAllUsers');
  }

  EditUser(User: any){
    return this.http.post(Globals.apiUrl + '/Users/EditUser', User);
  }

  AddUser(User: any){
    return this.http.post(Globals.apiUrl + '/Users/AddUser', User);
  }

  DeleteUser(id: any){
    return this.http.get(Globals.apiUrl + '/Users/DeleteUser?id=' + id);
  }

}
