import MainCard from '@common/ui-component/cards/main-card.tsx';
import { CapacitacionFormulario } from '../common/capacitacion-formulario.tsx';
import { Row } from '@components/ui-layout/row.tsx';
import { Col } from '@components/ui-layout/col.tsx';

import { useNotification } from '@components/snackbar/use-notification.ts';
import { crearCapacitacion } from './api.ts';
import { Button } from '@components/button/button.tsx';

const nameForm = 'cualquierCosa';

const Pagina = () => {
  const { success } = useNotification();

  const guardar = async (values: any) => {
    console.log('INSERTAR', values);

    // Aquí es donde se llaman los datos para crear la capacitación.
    await crearCapacitacion({
      id: '3ed540e2-4c9b-4228-a99f-a8a6c5d695d7',
      codigoCapacitacion: values.codigoCapacitacion,
      nombreCorto: values.nombreCorto,
      nombreLargo: values.nombreLargo,
      descripcion: values.descripcion,
      enteCapacitador: values.enteCapacitador,
      modalidad: values.modalidad.id,
      lugar: values.lugar,
      horario: values.horario,
      fechaInicioRegistro: values.fechaInicioRegistro,
      fechaFinRegistro: values.fechaFinRegistro,
      estado: values.estado.id,
    });

    success('Capacitación guardada correctamente');
  };

  return (
    <MainCard xs={{ maxWidth: '1200px' }}>
      <CapacitacionFormulario
        onSubmit={values => guardar(values)} // Se pasa `values` con el tipo `any`
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
