import {Injectable} from "@angular/core";
import { Router } from '@angular/router';
import {User} from "../../models/user.model";

@Injectable()
export class StorageService {

  private localStorageService;
  private currentSession : User = null;

  constructor(private router: Router) {
    this.localStorageService = localStorage;
    this.currentSession = this.loadSessionData();
  }

  setCurrentSession(session: User): void {
    this.currentSession = session;
    this.localStorageService.setItem('currentUser', JSON.stringify(session));
  }

  loadSessionData(): User{
    var sessionStr = this.localStorageService.getItem('currentUser');
    return (sessionStr) ? <User> JSON.parse(sessionStr) : null;
  }

  getCurrentSession(): User {   
    return this.currentSession;
  }

  removeCurrentSession(): void {
    this.localStorageService.removeItem('currentUser');
    this.currentSession = null;
  }

  getCurrentUser(): User {
    var session: User = this.getCurrentSession();
    return (session) ? session : null;
  };

  isAuthenticated(): boolean {
    return (this.currentSession != null) ? true : false;
  };

  getCurrentToken(): string {
    var session = this.getCurrentSession();
    return (session && session.name) ? session.name : null;
  };

  logout(): void{
    this.removeCurrentSession();
    this.router.navigate(['/login']);
  }

}