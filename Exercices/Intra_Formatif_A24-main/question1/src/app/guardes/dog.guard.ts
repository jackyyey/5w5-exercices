import { inject } from '@angular/core';
import { CanActivateFn, createUrlTreeFromSnapshot } from '@angular/router';
import { UserService } from '../user.service';

export const dogGuard: CanActivateFn = (route, state) => {
  if (inject(UserService).currentUser!.prefercat){
    return true;
  }
  else{
    return createUrlTreeFromSnapshot(route, ["/dog"]);
  }
};
