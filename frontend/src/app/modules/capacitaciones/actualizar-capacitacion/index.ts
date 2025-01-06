import Loadable from '@common/ui-component/Loadable.tsx';
import { lazy } from 'react';

const ActualizarCapacitacion = Loadable(lazy(() => import('./pagina')));

export default ActualizarCapacitacion;

