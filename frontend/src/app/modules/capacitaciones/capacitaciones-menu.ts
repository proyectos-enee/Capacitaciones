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
      id: 'administrarCapacitaciones',
      title: 'Administrar Capacitaciones',
      type: 'item',
      url: '/capacitaciones',
      icon: IconDashboard,
      breadcrumbs: true,
      access: [],
      children: [
        {
          id: 'Crear',
          title: 'Crear capacitación',
          type: 'item',
          url: '/capacitaciones/crear',
          icon: IconDashboard,
          breadcrumbs: true,
          access: [],
        },
        {
          id: 'detalles',
          title: 'Ver detalles',
          type: 'item',
          url: '/capacitaciones/detalles',
          icon: IconDashboard,
          breadcrumbs: true,
          access: [],
        },

      ],
    },
    {
      id: 'visualizacionCapacitaciones',
      title: 'Visualización de Capacitaciones Disponibles',
      type: 'item',
      url: '/capacitaciones/visualizar',
      icon: IconDashboard,
      breadcrumbs: true,
      access: [],
    },
    {
      id: 'registroCapacitacion',
      title: 'Registro a Capacitación',
      type: 'item',
      url: '/capacitaciones/registro',
      icon: IconDashboard,
      breadcrumbs: true,
      access: [],
    },
    {
      id: 'actualizacionDatos',
      title: 'Actualizacion de datos empleado',
      type: 'item',
      url: '/capacitaciones/actualizacion',
      icon: IconDashboard,
      breadcrumbs: true,
      access: [],
    },
    {
      id: 'solicitud',
      title: 'Solicitud de capacitaciónes',
      type: 'item',
      url: '/capacitaciones/solicitud',
      icon: IconDashboard,
      breadcrumbs: true,
      access: [],
    },
  ],
};
