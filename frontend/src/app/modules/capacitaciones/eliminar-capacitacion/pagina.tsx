import MainCard from '@common/ui-component/cards/main-card.tsx';
import { CapacitacionFormulario } from '../common/capacitacion-formulario.tsx';
import { Row } from '@components/ui-layout/row.tsx';
import { Col } from '@components/ui-layout/col.tsx';

import { useNotification } from '@components/snackbar/use-notification.ts';
import { eliminarCapacitacion } from './api.ts';
import { Button } from '@components/button/button.tsx';

const nameForm = 'cualquierCosa';

const Pagina = () => {
  const { success, error } = useNotification(); // También manejamos errores

  const eliminar = async (values: any) => {
    console.log('ELIMINAR', values);

    try {
      // Intentamos eliminar la capacitación
      await eliminarCapacitacion({
        codigoCapacitacion: values.codigoCapacitacion, // Usamos el código capturado
      });

      success('Capacitación eliminada correctamente');
    } catch (err) {
      error('Hubo un problema al eliminar la capacitación');
      console.error(err); // Puedes loguear el error para mayor detalle
    }
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
