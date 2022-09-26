import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IZooKeeper, ZooKeeper } from "../models/zooKeeper.model";

@Injectable({
  providedIn: "root",
})
export class ZooKeeperService {
  private baseUrl: string = "https://localhost:44329/";

  getHttpOptionsTextResponse() {
    const httpOptions = {
      responseType: "text" as "json",
      headers: new HttpHeaders({
        "Content-Type": "application/json",
      }),
    };
    return httpOptions;
  }

  constructor(private http: HttpClient) {}

  getAll$(): Observable<IZooKeeper[]> {
    return this.http.get<IZooKeeper[]>(this.baseUrl + "api/Zoo");
  }

  addZooKeeper$(model): Observable<IZooKeeper> {
    let zooKeeper = { name: model.name };
    return this.http.post<IZooKeeper>(this.baseUrl + "api/Zoo", zooKeeper);
  }

  deleteZooKeeper(id: number) {
    return this.http.delete<IZooKeeper>(
      this.baseUrl + "api/Zoo/" + id,
      this.getHttpOptionsTextResponse()
    );
  }

  updateZooKeeper$(id: number, model): Observable<IZooKeeper> {
    let zooKeeper = { name: model.name };
    return this.http.put<IZooKeeper>(
      this.baseUrl + "api/Zoo/" + id,
      zooKeeper,
      this.getHttpOptionsTextResponse()
    );
  }
}
