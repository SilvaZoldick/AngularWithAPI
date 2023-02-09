import { ListComponent } from './components/movies/list/list.component';
import { EditComponent } from './components/movies/edit/edit.component';
import { DetailsComponent } from './components/movies/details/details.component';
import { CreateComponent } from './components/movies/create/create.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/auth/login/login.component';

const routes: Routes = [
  {
    path: '',
    component: LoginComponent
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: "movies",
    component: ListComponent
  },
  {
    path: "movies/create",
    component: CreateComponent
  },
  {
    path: "movies/:id",
    component: DetailsComponent
  },
  {
    path: "movies/edit/:id",
    component: EditComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
