export class ContactModel {
  firstName: string;
  lastName: number;
  email: number;
  phoneNumber: string;
  status: number
  constructor() { }
}

export class ResponseModel<T>{
  resultCode: number;
  result: T
}
