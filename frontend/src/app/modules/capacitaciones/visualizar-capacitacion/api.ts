import { httpApi } from '../../../http/http-api.ts';

// Definición del modelo de Capacitación
export interface Capacitacion {
  id: string;
  codigoCapacitacion: string;
  nombreCorto: string;
  nombreLargo: string;
  descripcion: string;
  enteCapacitador: string;
  modalidad: string;
  lugar: string;
  horario: string;
  fechaInicioRegistro: string;
  fechaFinRegistro: string;
  estado: string;
}

// Obtener capacitaciones disponibles
export const obtenerCapacitacionesDisponibles = async (params: {
  nombreCorto?: string;
  modalidad?: string;
  fechaInicioRegistro?: string;
  fechaFinRegistro?: string;
}) => {
  return httpApi.get<Capacitacion[]>('/capacitacion/capacitaciones/disponibles', { params });
};
