import { httpApi } from '../../../http/http-api.ts';
import { Capacitacion } from '../common/capacitacion.model.ts';

export const eliminarCapacitacion = async (values: Capacitacion) => {
  return httpApi.delete('', values);
};
