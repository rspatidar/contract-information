export class ContactModel {
  id?: number;
  firstName: string;
  lastName: string;
  email: string;
  phoneNumber: string;
  status: number
  constructor() { }
}

export class ResponseModel<T>{
  resultCode: number;
  result: T
}
