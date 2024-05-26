// refresh.service.ts
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RefreshService {
  // Create a Subject to emit events
  private refreshSubject = new Subject<void>();

  // Expose the Subject as an Observable
  refresh$ = this.refreshSubject.asObservable();

  // Method to trigger a refresh event
  triggerRefresh() {
    this.refreshSubject.next();
  }
}
