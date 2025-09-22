import { CanActivateFn, createUrlTreeFromSnapshot } from '@angular/router';

export const foodGuard: CanActivateFn = (route, state) => {
  var sucre: string | null = localStorage.getItem("sucre");
  var sel: string | null = localStorage.getItem("sel");

  var sucree: boolean = false;
  var salee: boolean = false;
  if (sucre != null){
    sucree = JSON.parse(sucre);
  }
  if (sel != null){
    salee = JSON.parse(sel);
  }

  
  if(salee == false && sucree == true){
    return createUrlTreeFromSnapshot(route, ["/bonbon"])
  }
  else if(salee == true && sucree == false){
    return createUrlTreeFromSnapshot(route, ["/sel"])
  }
  else if (salee == false && sucree == false){
    return createUrlTreeFromSnapshot(route, ["/verreDEau"]);
  }
  return true;
};
