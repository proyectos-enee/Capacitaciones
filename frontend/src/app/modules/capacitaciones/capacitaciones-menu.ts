import { Menu } from '../../../common/menu-items/models/menu.ts';
import { IconDashboard } from '@tabler/icons-react';

export const CapacitacionesMenu: Menu = {
  id: 'capacitaciones',
  title: 'Capacitaciones',
  type: 'group',
  access: [],
  breadcrumbs: true,
  children: [

    {
      id: 'leerCapacitaciones',
      title: 'Leer Capacitaciones',
      type: 'item',
      url: '/capacitaciones',
      icon: IconDashboard,
      breadcrumbs: true,
      access: [],
      children:[
        {

          id: 'Crear',
          title: 'Crear capacitacion',
          type: 'item',
          url: '/capacitaciones/crear',
          icon: IconDashboard,
          breadcrumbs: true,
          access: [],
        },
      ]
    },
  ],
};
