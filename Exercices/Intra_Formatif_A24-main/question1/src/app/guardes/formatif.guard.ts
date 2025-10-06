import { inject } from '@angular/core';
import { CanActivateFn, createUrlTreeFromSnapshot } from '@angular/router';
import { UserService } from '../user.service';

export const formatifGuard: CanActivateFn = (route, state) => {
  if (inject(UserService).currentUser == null){
    return createUrlTreeFromSnapshot(route, ["/login"]);
  }
  else return true;
};
