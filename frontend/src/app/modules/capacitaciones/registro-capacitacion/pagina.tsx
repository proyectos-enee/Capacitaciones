import { httpApi } from '../../../http/http-api.ts';
import { usePaginate } from '@common/hooks/use-paginate.ts';
import { useState } from 'react';
import { PaginableGrid } from '@components/grid/paginable-grid.tsx';
import { PaginateResult } from '@common/hooks/models/paginate-result.ts';
import MainCard from '@common/ui-component/cards/main-card.tsx';
import { ColumnDef } from '@components/grid/models/column-def.tsx';
import InfoIcon from '@mui/icons-material/Info';
import { Button } from '@components/button/button.tsx';
import { Dialog, DialogTitle, DialogContent, DialogActions } from '@mui/material';

const Pagina = () => {
  const [search, setSearch] = useState<any>({
    ClaveEmpleado: '', // Valor predeterminado para probar la API
    PageSize: 5,
    Page: 1,
  });

  const [openDialog, setOpenDialog] = useState(false);
  const [selectedColaboradores, setSelectedColaboradores] = useState<any>(null);

  // Consulta paginada
  const [{ data }] = usePaginate<any>(httpApi, '/capacitacion/Test', search, {
    pageIn: 1,
    sizeIn: 5,
    sizeOptions: [5, 10],
  });

  const buscarColaboradores = () => {
    setSearch({ ...search }); // Refrescar búsqueda
  };

  const columns: ColumnDef[] = [
    {
      headerName: 'Acciones',
      renderCell: (rowData: any) => (
        <Button
          color="secondary"
          startIcon={<InfoIcon />}
          onClick={() => {
            setSelectedColaboradores(rowData);
            setOpenDialog(true);
          }}
          key={rowData.id}
        >
          Ver Detalles
        </Button>
      ),
    },
    {
      headerName: 'Nombre',
      field: 'nombre',
    },
    {
      headerName: 'Cargo',
      field: 'cargo',
    },
    {
      headerName: 'Correo',
      field: 'correo',
    },
    {
      headerName: 'Dependencia',
      field: 'dependencia',
    },
  ];

  return (
    <>
      <MainCard xs={{ maxWidth: '1200px' }}>
        <div
          style={{
            display: 'flex',
            justifyContent: 'space-between',
            marginTop: '20px',
          }}
        >
          {/* Filtros */}
          <div style={{ display: 'flex', gap: '10px' }}>
            <input
              type="text"
              placeholder="Clave Empleado"
              value={search.ClaveEmpleado || ''}
              onChange={(e) => setSearch({ ...search, ClaveEmpleado: e.target.value })}
              style={{ padding: '5px', width: '200px' }}
            />
            <Button onClick={buscarColaboradores}>Buscar</Button>
          </div>
        </div>

        {/* Tabla de capacitaciones */}
        <PaginableGrid
          paginable={data as PaginateResult<any>}
          columnDefs={columns}
          getRowId={(row: any) => row.id}
        />
      </MainCard>

      {/* Diálogo de Detalles */}
      <Dialog
        open={openDialog}
        onClose={() => setOpenDialog(false)}
        maxWidth="sm"
        fullWidth
      >
        <DialogTitle>Detalles de la Capacitación</DialogTitle>
        <DialogContent>
          {selectedColaboradores && (
            <div>
              <p>
                <strong>Nombre:</strong> {selectedColaboradores.nombre || 'N/A'}
              </p>
              <p>
                <strong>Cargo:</strong> {selectedColaboradores.cargo || 'N/A'}
              </p>
              <p>
                <strong>Correo:</strong> {selectedColaboradores.correo || 'N/A'}
              </p>
              <p>
                <strong>Dependencia:</strong> {selectedColaboradores.dependencia || 'N/A'}
              </p>
              <p>
                <strong>Estado:</strong> {selectedColaboradores.estado || 'N/A'}
              </p>
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
