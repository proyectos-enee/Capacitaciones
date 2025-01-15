import Loadable from '@common/ui-component/Loadable.tsx';
import { lazy } from 'react';

const VisualizarCapacitacion = Loadable(lazy(() => import('./pagina')));

export default VisualizarCapacitacion;

