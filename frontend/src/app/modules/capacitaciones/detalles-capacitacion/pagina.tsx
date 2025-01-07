import { useState } from 'react';
import { Dialog, DialogTitle, DialogContent, DialogActions, Button } from '@mui/material';

import { PaginableGrid } from '@components/grid/paginable-grid.tsx';

import InfoIcon from '@mui/icons-material/Info';
import { ActionColumn, generateActionColumn } from '@components/grid/components/action-column.tsx';

const Pagina = () => {
  const [openDialog, setOpenDialog] = useState(false);
  const [selectedCapacitacion, setSelectedCapacitacion] = useState<any>(null);

  const actions: Array<ActionColumn> = [
    // Otras acciones...
    {
      color: 'secondary',
      icon: <InfoIcon />,
      label: 'Ver Detalles',
      onClick: (rowData: any) => {
        setSelectedCapacitacion(rowData); // Guarda los datos de la capacitación seleccionada
        setOpenDialog(true); // Abre el diálogo
      },
    },
  ];

  return (
    <>
      <PaginableGrid
        columnDefs={[
          {
            headerName: 'Acciones',
            renderCell: generateActionColumn(actions),
          },
          {
            headerName: 'Código Capacitación',
            field: 'codigoCapacitacion',
          },
          {
            headerName: 'Nombre Corto',
            field: 'nombreCorto',
          },
          {
            headerName: 'Estado',
            field: 'estado',
          },
        ]}
      />

      {/* Diálogo de Detalles */}
      <Dialog open={openDialog} onClose={() => setOpenDialog(false)} maxWidth="sm" fullWidth>
        <DialogTitle>Detalles de la Capacitación</DialogTitle>
        <DialogContent>
          {selectedCapacitacion && (
            <div>
              <p><strong>Código:</strong> {selectedCapacitacion.codigoCapacitacion}</p>
              <p><strong>Nombre Corto:</strong> {selectedCapacitacion.nombreCorto}</p>
              <p><strong>Nombre Largo:</strong> {selectedCapacitacion.nombreLargo || 'N/A'}</p>
              <p><strong>Descripción:</strong> {selectedCapacitacion.descripcion || 'N/A'}</p>
              <p><strong>Estado:</strong> {selectedCapacitacion.estado}</p>
              <p><strong>Modalidad:</strong> {selectedCapacitacion.modalidad?.name || 'N/A'}</p>
              <p><strong>Fecha de Inicio:</strong> {selectedCapacitacion.fechaInicioRegistro}</p>
              <p><strong>Fecha de Fin:</strong> {selectedCapacitacion.fechaFinRegistro}</p>
              <p><strong>Lugar:</strong> {selectedCapacitacion.lugar || 'N/A'}</p>
            </div>
          )}
        </DialogContent>
        <DialogActions>
          <Button onClick={() => setOpenDialog(false)} color="primary">
            Cerrar
          </Button>
        </DialogActions>
      </Dialog>
    </>
  );
};

export default Pagina;
