import MainCard from '@common/ui-component/cards/main-card.tsx';
import { CapacitacionFormulario } from '../common/capacitacion-formulario.tsx';
import { Row } from '@components/ui-layout/row.tsx';
import { Col } from '@components/ui-layout/col.tsx';

import { useNotification } from '@components/snackbar/use-notification.ts';
import { eliminarCapacitacion } from './api.ts';
import { Button } from '@components/button/button.tsx';

const nameForm = 'cualquierCosa';

const Pagina = () => {
  const { success } = useNotification();

  const eliminar = async (values: any) => {
    console.log('ELIMINAR', values);

    // Aquí es donde se llaman los datos para crear la capacitación.
    await eliminarCapacitacion({
      id: '3ed540e2-4c9b-4228-a99f-a8a6c5d695d7', // ID generado (puedes generar uno dinámicamente si es necesario)
      codigoCapacitacion: values.codigoCapacitacion, // Usamos el código capturado
      nombreCorto: values.nombreCorto,
      nombreLargo: values.nombreLargo,
      descripcion: values.descripcion, // Campo opcional
      enteCapacitador: values.enteCapacitador,
      modalidad: values.modalidad.id, // Aquí asumimos que modalidad es un objeto con un `id`
      lugar: values.lugar, // Campo opcional
      horario: values.horario, // Campo opcional
      fechaInicioRegistro: values.fechaInicioRegistro,
      fechaFinRegistro: values.fechaFinRegistro,
      estado: values.estado.id, // Aquí asumimos que estado es un objeto con un `id`
    });

    success('Capacitación eliminada correctamente');
  };

  return (
    <MainCard xs={{ maxWidth: '1200px' }}>
      <CapacitacionFormulario
        onSubmit={values => eliminar(values)} // Se pasa `values` con el tipo `any`
        nombreFormulario={nameForm}
      />
      <Row>
        <Col>
          <Button form={nameForm} type="submit">
            Eliminar
          </Button>
        </Col>
      </Row>
    </MainCard>
  );
};

export default Pagina;
