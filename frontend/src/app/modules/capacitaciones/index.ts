import Loadable from '@common/ui-component/Loadable.tsx';
import { lazy } from 'react';

const CapacitacionesModule = Loadable(lazy(() => import('./capacitaciones-routing')));

export default CapacitacionesModule;
