import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IAnimal } from "../models/animal.model";

@Injectable({
  providedIn: "root",
})
export class AnimalService {
  private baseUrl: string = "https://localhost:44329/api/Zoo/animals";

  getHttpOptionsTextResponse() {
    const httpOptions = {
      responseType: "text" as "json",
      headers: new HttpHeaders({
        "Content-Type": "application/json",
      }),
    };
    return httpOptions;
  }

  readonly httpOptions = {
    headers: new HttpHeaders({
      "Content-Type": "application/json",
    }),
  };

  constructor(private http: HttpClient) {}

  getAllAnimalsByZooKeeper$(id: number): Observable<IAnimal[]> {
    return this.http.get<IAnimal[]>(this.baseUrl + "/" + id, this.httpOptions);
  }

  addAnimal$(model): Observable<IAnimal> {
    let animal = {
      animalType: model.animalType,
      dateOfBirth: model.dateOfBirth,
      zooKeeperId: model.zooKeeperId,
    };
    return this.http.post<IAnimal>(this.baseUrl, animal);
  }
}
