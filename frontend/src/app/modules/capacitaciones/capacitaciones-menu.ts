import { Menu } from '../../../common/menu-items/models/menu.ts';
import { IconDashboard } from '@tabler/icons-react';

export const CapacitacionesMenu: Menu = {
  id: 'capacitaciones',
  title: 'Administrar Capacitaciones',
  type: 'group',
  access: [],
  breadcrumbs: true,
  children: [
    {
      id: 'listadoCapacitaciones',
      title: 'Listado de Capacitaciones',
      type: 'item',
      url: '/capacitaciones',
      icon: IconDashboard,
      breadcrumbs: true,
      access: [],
      children: [
        {
          id: 'crearCapacitacion',
          title: 'Crear Capacitación',
          type: 'item',
          url: '/capacitaciones/crear',
          icon: IconDashboard,
          breadcrumbs: true,
          access: [],


        },
      ],
    },
  ],
};
