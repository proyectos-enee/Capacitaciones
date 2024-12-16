import Loadable from '@common/ui-component/Loadable.tsx';
import { lazy } from 'react';

const CrearCapacitacion = Loadable(lazy(() => import('./pagina')));

export default CrearCapacitacion;

