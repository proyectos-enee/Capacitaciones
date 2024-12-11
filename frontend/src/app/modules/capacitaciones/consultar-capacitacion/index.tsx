import Loadable from '@common/ui-component/Loadable.tsx';
import { lazy } from 'react';

const ConsultarCapacitacion = Loadable(lazy(() => import('./pagina')));

export default ConsultarCapacitacion;
