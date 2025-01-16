import { httpApi } from '../../../http/http-api.ts';


export const VisualizarCapacitacion = async (filtros: any) => {
  return httpApi.get('', { params: filtros });
};

