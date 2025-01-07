import { httpApi } from '../../../http/http-api.ts';

export const actualizarCapacitacion = async (id: string, data: any) => {
  return httpApi.put(`/capacitacion/${id}`, data);
};
