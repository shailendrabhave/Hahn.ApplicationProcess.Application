interface Applicant {
  id: number;
  name: string;
  familyName: string;
  address: string;
  countryOfOrigin: string;
  emailAddress: string;
  age: number;
  hired: boolean;
  createdDate: any;
  modifiedDate: any;
}

export class App {
  name: string;
  applicant: Applicant;
  message: string;

  constructor() {
    this.applicant = { id: 0, name: '', familyName: '', address: '', countryOfOrigin: '', emailAddress: '', age: 0, hired: false, createdDate: '', modifiedDate: '' };
  }

  registerApplicant(e) {
    
  }

}


