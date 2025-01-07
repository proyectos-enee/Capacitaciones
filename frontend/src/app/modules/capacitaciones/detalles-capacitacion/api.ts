import { httpApi } from '../../../http/http-api.ts';
import { Capacitacion } from '../common/capacitacion.model.ts';

export const consultarCapacitacion = async (values: Capacitacion) => {
  return httpApi.post('', values);
};
