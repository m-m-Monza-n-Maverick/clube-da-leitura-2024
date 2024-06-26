﻿using System.Collections;
namespace ControleMedicamentos.ConsoleApp.Compartilhado
{
    public abstract class EntidadeBase
    {
        public string Nome { get; set; }
        public string Etiqueta { get; set; }
        public string Titulo { get; set; }
        public int Id { get; set; }

        public abstract List<string> Validar();
        public abstract void AtualizarRegistro(EntidadeBase novoRegistro);

        #region Auxiliares
        protected void VerificaNulo(ref List<string> erros, string campoTestado, string mostraCampo)
        {
            if (string.IsNullOrEmpty(campoTestado))
                erros.Add($"\nO campo \"{mostraCampo}\" é obrigatório. Tente novamente ");
        }
        protected void VerificaNulo(ref List<string> erros, EntidadeBase campoTestado)
        {
            if (campoTestado == null)
                erros.Add($"\nEste item não existe. Tente novamente ");
        }
        protected void VerificaTamanho(ref List<string> erros, string campoTestado, string mostraCampo, int tamanho)
        {
            if (string.IsNullOrEmpty(campoTestado))
                erros.Add($"\nO campo \"{mostraCampo}\" é obrigatório. Tente novamente ");

            else if (campoTestado.Trim().Length < tamanho)
                erros.Add($"O(a) \"{mostraCampo}\" precisa ter mais do que {tamanho} caracteres. Tente novamente ");
        }
        protected void VerificaDataValidade(ref List<string> erros, DateTime DataValidade)
        {
            DateTime hoje = DateTime.Now.Date;
            if (DataValidade < hoje)
                erros.Add("\nO campo \"data de validade\" não pode ser menor que a data atual. Tente novamente ");
            else if (DataValidade.Year > 2100)
                erros.Add($"\n{DataValidade.Year}? Também não despiroque né. Tente novamente ");
        }
        #endregion
    }
}
