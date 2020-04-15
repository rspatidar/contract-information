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
    return this._http.get<ResponseModel<ContactModel[]>>(this._baseUrl + 'contact/getcontact').pipe(
      tap((response: ResponseModel<ContactModel[]>) => { return response }));

  }
}
