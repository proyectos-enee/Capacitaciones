import Loadable from '@common/ui-component/Loadable.tsx';
import { lazy } from 'react';

const RegistroCapacitacion = Loadable(lazy(() => import('./pagina')));

export default RegistroCapacitacion;

