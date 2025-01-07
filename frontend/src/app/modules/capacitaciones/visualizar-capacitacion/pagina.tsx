import { useNotification } from '@components/snackbar/use-notification.ts';
import { useState } from 'react';
import { Dialog, DialogTitle, DialogContent, DialogActions, Button, TextField, Typography, Box } from '@mui/material';
import MainCard from '@common/ui-component/cards/main-card.tsx';
import { httpApi } from '../../../http/http-api.ts';
import { PaginableGrid } from '@components/grid/paginable-grid.tsx';
import { ColumnDef } from '@components/grid/models/column-def.tsx';
import { ActionColumn, generateActionColumn } from '@components/grid/components/action-column.tsx';
import InfoIcon from '@mui/icons-material/Info';
import CheckIcon from '@mui/icons-material/Check';

const VisualizarCapacitaciones = () => {
  const { success, error } = useNotification();
  const [search, setSearch] = useState<any>({});
  const [capacitaciones, setCapacitaciones] = useState<any[]>([]); // Lista de capacitaciones
  const [openDialog, setOpenDialog] = useState(false); // Control del diálogo
  const [selectedCapacitacion, setSelectedCapacitacion] = useState<any>(null); // Capacitación seleccionada

  // Cargar capacitaciones disponibles al iniciar
  const fetchCapacitaciones = async () => {
    try {
      const response = await httpApi.get('/api/v1/capacitaciones', {
        params: {
          estado: 'disponible',
          fechaInicioRegistro: new Date().toISOString(),
        },
      });
      setCapacitaciones(response.data);
    } catch (err) {
      console.error('Error al cargar capacitaciones:', err);
      error('Error al cargar las capacitaciones disponibles.');
    }
  };

  // Filtrar capacitaciones
  const filtrarCapacitaciones = async () => {
    try {
      const response = await httpApi.get('/api/v1/capacitaciones', {
        params: {
          estado: 'disponible',
          nombreCorto: search.nombreCorto || undefined,
          modalidad: search.modalidad || undefined,
          fechaInicioRegistro: search.fechaInicio || undefined,
          fechaFinRegistro: search.fechaFin || undefined,
        },
      });
      setCapacitaciones(response.data);
    } catch (err) {
      console.error('Error al filtrar capacitaciones:', err);
      error('Error al filtrar las capacitaciones.');
    }
  };

  // Registrar usuario en una capacitación
  const registrarEnCapacitacion = async (capacitacionId: string) => {
    try {
      await httpApi.post(`/api/v1/capacitaciones/${capacitacionId}/registro`);
      success('Registro exitoso en la capacitación.');
      fetchCapacitaciones(); // Recargar lista
    } catch (err) {
      console.error('Error al registrarse:', err);
      error('Ya estás registrado o no se pudo completar el registro.');
    }
  };

  const actions: Array<ActionColumn> = [
    {
      color: 'secondary',
      icon: <InfoIcon />,
      label: 'Ver Detalles',
      onClick: (rowData: any) => {
        setSelectedCapacitacion(rowData);
        setOpenDialog(true);
      },
    },
    {
      color: 'primary',
      icon: <CheckIcon />,
      label: 'Registrarse',
      onClick: (rowData: any) => registrarEnCapacitacion(rowData.id),
    },
  ];

  const columns: ColumnDef[] = [
    {
      headerName: 'Acciones',
      renderCell: generateActionColumn(actions),
    },
    {
      headerName: 'Nombre',
      field: 'nombreCorto',
    },
    {
      headerName: 'Modalidad',
      field: 'modalidad',
    },
    {
      headerName: 'Fecha Inicio',
      field: 'fechaInicioRegistro',
      renderCell: (rowData: any) =>
        rowData.fechaInicioRegistro ? new Date(rowData.fechaInicioRegistro).toLocaleDateString() : 'N/A',
    },
    {
      headerName: 'Fecha Fin',
      field: 'fechaFinRegistro',
      renderCell: (rowData: any) =>
        rowData.fechaFinRegistro ? new Date(rowData.fechaFinRegistro).toLocaleDateString() : 'N/A',
    },
  ];

  return (
    <>
      <MainCard xs={{ maxWidth: '1200px' }}>
        <Typography variant="h6" gutterBottom>
          Visualización de Capacitaciones Disponibles
        </Typography>
        <Box display="flex" gap={2} marginBottom={2}>
          <TextField
            label="Nombre"
            value={search.nombreCorto || ''}
            onChange={(e) => setSearch({ ...search, nombreCorto: e.target.value })}
          />
          <TextField
            label="Modalidad"
            value={search.modalidad || ''}
            onChange={(e) => setSearch({ ...search, modalidad: e.target.value })}
          />
          <TextField
            label="Fecha Inicio"
            type="date"
            InputLabelProps={{ shrink: true }}
            value={search.fechaInicio || ''}
            onChange={(e) => setSearch({ ...search, fechaInicio: e.target.value })}
          />
          <TextField
            label="Fecha Fin"
            type="date"
            InputLabelProps={{ shrink: true }}
            value={search.fechaFin || ''}
            onChange={(e) => setSearch({ ...search, fechaFin: e.target.value })}
          />
          <Button onClick={filtrarCapacitaciones} variant="contained">
            Filtrar
          </Button>
        </Box>
        <PaginableGrid rows={capacitaciones} columnDefs={columns} />

        {capacitaciones.length === 0 && (
          <Typography align="center" color="textSecondary" marginTop={2}>
            No hay datos disponibles.
          </Typography>
        )}
      </MainCard>

      {/* Diálogo de Detalles */}
      <Dialog open={openDialog} onClose={() => setOpenDialog(false)} maxWidth="sm" fullWidth>
        <DialogTitle>Detalles de la Capacitación</DialogTitle>
        <DialogContent>
          {selectedCapacitacion && (
            <Box>
              <Typography><strong>Nombre:</strong> {selectedCapacitacion.nombreCorto}</Typography>
              <Typography><strong>Modalidad:</strong> {selectedCapacitacion.modalidad}</Typography>
              <Typography>
                <strong>Fecha Inicio:</strong>{' '}
                {selectedCapacitacion.fechaInicioRegistro
                  ? new Date(selectedCapacitacion.fechaInicioRegistro).toLocaleDateString()
                  : 'N/A'}
              </Typography>
              <Typography>
                <strong>Fecha Fin:</strong>{' '}
                {selectedCapacitacion.fechaFinRegistro
                  ? new Date(selectedCapacitacion.fechaFinRegistro).toLocaleDateString()
                  : 'N/A'}
              </Typography>
              <Typography><strong>Descripción:</strong> {selectedCapacitacion.descripcion}</Typography>
            </Box>
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

export default VisualizarCapacitaciones;
