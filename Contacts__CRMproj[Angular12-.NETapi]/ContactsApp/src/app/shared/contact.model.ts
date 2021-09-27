export class Contact {
  id: number;
  name: string;
  mobilephone: string;
  jobtitle: string;
  birthdate: Date;
  
  constructor(id = 0, name = '', phone = '', job = '', birth = new Date("0000-00-00"))
  {
    this.id = id;
    this.name = name;
    this.mobilephone = phone;
    this.jobtitle = job;
    this.birthdate = birth;
  }

  static withJSON(json: any): Contact {
    /*if (!json || !json.id || !json.name || !json.mobilephone || !json.jobtitle || !json.birthdate)
      return undefined;*/
    return new Contact(json.Id, json.Name, json.MobilePhone,
                      json.JobTitle, json.BirthDate);
  }
}
