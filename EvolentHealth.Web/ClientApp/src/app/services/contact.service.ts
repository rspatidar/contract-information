import { Injectable, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { ContactModel, ResponseModel } from "../models/contact.model";
import { Observable } from "rxjs";
import { tap, catchError } from "rxjs/operators";


@Injectable()
export class ContactService {

  constructor(private _http: HttpClient, @Inject('BASE_URL') private _baseUrl: string) {

  }

  getcontactList(): Observable<ResponseModel<ContactModel[]>> {
    return this._http.get<ResponseModel<ContactModel[]>>(this._baseUrl + 'contact/getallcontact').pipe(
      tap((response: ResponseModel<ContactModel[]>) => { return response }));

  }
  getcontact(id:number): Observable<ResponseModel<ContactModel>> {
    return this._http.get<ResponseModel<ContactModel>>(this._baseUrl + 'contact/getcontact/'+id).pipe(
      tap((response: ResponseModel<ContactModel>) => { return response }));

  }
  deleteContact(id: number): Observable<number> {
    return this._http.delete<number>(this._baseUrl + 'contact/deletecontact/' + id).pipe(
      tap((response: number) => { return response }));

  }
  updateContact(contact: ContactModel): Observable<ResponseModel<ContactModel>> {
    return this._http.put<ResponseModel<ContactModel>>(this._baseUrl + 'contact/updatecontact', contact).pipe(
      tap((response: ResponseModel<ContactModel>) => { return response }));

  }
  AddContact(contact: ContactModel): Observable<ResponseModel<ContactModel>> {
    return this._http.post<ResponseModel<ContactModel>>(this._baseUrl + 'contact/addcontact', contact).pipe(
      tap((response: ResponseModel<ContactModel>) => { return response }));

  }

}
