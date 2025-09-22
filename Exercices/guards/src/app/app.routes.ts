import { Routes } from '@angular/router';
import { CaramelAuSel } from './caramel-au-sel/caramel-au-sel';
import { VerreDEau } from './verre-deau/verre-deau';
import { Bonbon } from './bonbon/bonbon';
import { Sel } from './sel/sel';
import { App } from './app';
import { foodGuard } from './food-guard';

export const routes: Routes = [
    {
        path: 'caramelAuSel', component: CaramelAuSel, canActivate:[foodGuard]
    },
    {
        path: 'verreDEau', component: VerreDEau
    },
    {
        path: 'bonbon', component: Bonbon
    },
    {
        path: 'sel', component: Sel
    }
];
