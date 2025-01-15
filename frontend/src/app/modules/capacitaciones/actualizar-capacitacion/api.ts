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


// Actualizar una capacitación existente por ID
export const actualizarCapacitacion = async (id: string, values: Capacitacion) => {
  return httpApi.put(`/capacitacion/${id}`, values);
};

