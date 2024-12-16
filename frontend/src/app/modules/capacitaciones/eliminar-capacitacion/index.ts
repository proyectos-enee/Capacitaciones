import Loadable from '@common/ui-component/Loadable.tsx';
import { lazy } from 'react';

const EliminarCapacitacion = Loadable(lazy(() => import('./pagina')));

export default EliminarCapacitacion;
