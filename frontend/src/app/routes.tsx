import { RouteObject } from 'react-router-dom';


import HomeModule from './modules/home';
import CapacitacionesModule from './modules/capacitaciones';



export const AppRoutes: Array<RouteObject> = [
  {
    path: '/',
    element: <HomeModule />,
  },
  {
    path: 'capacitaciones/*',
    element: <CapacitacionesModule />,
  }
];
