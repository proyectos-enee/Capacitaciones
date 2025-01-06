import React from 'react';
import { useForm, FormProvider } from 'react-hook-form';
import { yupResolver } from '@hookform/resolvers/yup';
import { FieldValues, SubmitErrorHandler, UseFormReturn, ValidationMode } from 'react-hook-form';

const sleep = (ms: number) => new Promise(resolve => setTimeout(resolve, ms));

export interface HookFormProps {
  onSubmit?: (data: FieldValues, reset: () => void) => void;
  onErrorSubmit?: SubmitErrorHandler<FieldValues>;
  validations?: any;
  children: (methods: UseFormReturn) => React.ReactNode;
  defaultValues?: any; // Usar `defaultValues` directamente
  nameForm?: string;
  validationMode?: keyof ValidationMode;
  isLoading?: boolean;
}

export const HookForm: React.FC<HookFormProps> = ({
                                                    onSubmit,
                                                    onErrorSubmit,
                                                    validations,
                                                    children,
                                                    defaultValues = {}, // Valores iniciales predeterminados
                                                    nameForm,
                                                    validationMode = 'onChange',
                                                  }) => {
  const methods = useForm({
    resolver: validations ? yupResolver(validations) : undefined,
    defaultValues, // Pasar valores iniciales a React Hook Form
    mode: validationMode,
  });

  const { handleSubmit, formState } = methods;

  const submit = async (data: FieldValues) => {
    if (onSubmit) {
      await onSubmit(data, methods.reset);
      await sleep(300); // Simulación de retardo
    }
  };

  return (
    <FormProvider {...methods}>
      <form
        id={nameForm}
        noValidate
        autoComplete="off"
        onSubmitCapture={
          formState.isSubmitting
            ? (e) => e.preventDefault()
            : handleSubmit(submit, onErrorSubmit)
        }
      >
        {children(methods)}
      </form>
    </FormProvider>
  );
};
