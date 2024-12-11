import MainCard from '@common/ui-component/cards/main-card.tsx';
import { CapacitacionFormulario } from '../common/capacitacion-formulario.tsx';
import { Row } from '@components/ui-layout/row.tsx';
import { Col } from '@components/ui-layout/col.tsx';

import { useNotification } from '@components/snackbar/use-notification.ts';
import { crearCapacitacion } from './api.ts';
import { Button } from '@components/button/button.tsx';

const nameForm = 'formularioCapacitacion';
const Pagina = () => {
  const { success, error } = useNotification();

  const guardar = async (values: any) => {
    try {
      console.log('INSERTAR', values);
      await crearCapacitacion({
        id: '', // El ID puede generarse en el backend
        codigoCapacitacion: values.codigoCapacitacion,
        nombreCorto: values.nombreCorto,
        nombreLargo: values.nombreLargo,
        descripcion: values.descripcion || '',
        enteCapacitador: values.enteCapacitador,
        modalidad: values.modalidad.id, // Asegúrate de enviar el ID de la modalidad
        lugar: values.lugar || '',
        horario: values.horario || '',
        fechaInicioRegistro: values.fechaInicioRegistro,
        fechaFinRegistro: values.fechaFinRegistro,
        estado: values.estado.id, // Asegúrate de enviar el ID del estado
      });
      success('Capacitación guardada correctamente');
    } catch (e) {
      console.error('Error al guardar la capacitación:', e);
      error('Ocurrió un error al guardar la capacitación');
    }
  };

  return (
    <MainCard xs={{ maxWidth: '1200px' }}>
      <CapacitacionFormulario
        onSubmit={values => guardar(values)}
        nombreFormulario={nameForm}
      />
      <Row>
        <Col>
          <Button form={nameForm} type="submit">
            Guardar
          </Button>
        </Col>
      </Row>
    </MainCard>
  );
};

export default Pagina;

