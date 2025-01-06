import { httpApi } from '../../../http/http-api.ts';
import { Capacitacion } from '../common/capacitacion.model.ts';

export const actualizarCapacitacion = async (values: Capacitacion) => {
  return httpApi.put('', values);
};
