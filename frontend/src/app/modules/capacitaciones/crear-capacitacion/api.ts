import { httpApi } from '../../../http/http-api.ts';
import { Capacitacion } from '../common/capacitacion.model.ts';

export const crearCapacitacion = async (values: Capacitacion) => {
  return httpApi.post('capacitacion', values);
};
