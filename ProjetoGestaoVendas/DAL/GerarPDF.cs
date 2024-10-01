using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//ESSAS SAO AS BIBLIOTECAS QUE DEVEREMOS ADICIONAR EM NOSSO PROJETO
using System.IO;// A BIBLIOTECA DE ENTRADA E SAIDA DE ARQUIVOS

using iTextSharp;//E A BIBLIOTECA ITEXTSHARP E SUAS EXTENÇÕES
using iTextSharp.text;//ESTENSAO 1 (TEXT)
using iTextSharp.text.pdf;//ESTENSAO 2 (PDF)
namespace ProjetoGestaoVendas.DAL
{
    internal class GerarPDF
    {

        public void PDF(List<(string NomeProduto, decimal Preco)>produtos)
        {
            Document doc = new Document(PageSize.A4);
            doc.SetMargins(40, 40, 40, 80);
            doc.AddCreationDate();


            // Ajuste o caminho conforme necessário
            string dataArquivo = DateTime.Now.ToString("dd_MM_yyyy");
            string caminhoPDF = $@"C:\Users\Danilo\Documents\DUDA_ESTUDOS\ProjetoGestaoVendas\ProjetoGestaoVendas_Atualizado\ProjetoGestaoVendas\PDF\FechamnetoCaixa{dataArquivo}.pdf";
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(caminhoPDF, FileMode.Create));

            doc.Open();

            // Título do documento
            Paragraph titulo = new Paragraph("Fechamento de Caixa", new Font((Font.FontFamily)Font.BOLD, 18));
            titulo.Alignment = Element.ALIGN_CENTER;
            doc.Add(titulo);
            doc.Add(new Paragraph("\n")); // Espaço

            // Data do fechamento
            string dataFechamento = DateTime.Now.ToString("dd/MM/yyyy");
            Paragraph data = new Paragraph($"Data: {dataFechamento}", new Font(Font.NORMAL, 12));
            doc.Add(data);
            doc.Add(new Paragraph("\n")); // Espaço

            // Detalhes do fechamento
            Paragraph detalhes = new Paragraph("Detalhes do Fechamento:", new Font((Font.FontFamily)Font.BOLD, 14));
            doc.Add(detalhes);


            // Exemplo de dados (substitua pelos valores reais)

            foreach (var produto in produtos)
            {
                doc.Add(new Paragraph($"Produto: {produto.NomeProduto}, Preço: R$ {produto.Preco:F2}"));
            }

            doc.Add(new Paragraph("\n")); // Espaço

            // Assinatura ou observações finais
            Paragraph assinatura = new Paragraph("Assinatura: _______________________", new Font(Font.NORMAL, 12));
            doc.Add(assinatura);

            doc.Close();
        }
    }
}
