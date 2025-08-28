import { HttpInterceptorFn } from '@angular/common/http';

export const authHaterFnInterceptor: HttpInterceptorFn = (req, next) => {
  req = req.clone({
    setHeaders:{
      "Content-Type" : "application/json",
      "Authorization" : "Bearer " + sessionStorage.getItem("token")
    }
  })
  return next(req);
};
