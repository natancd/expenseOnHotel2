# Algumas considerações:

* Projeto desenvolvido em Visual Studio 2019.
* ASP.NET MVC em .NET Framework
* O projeto não está com uma tela inicial definida, mas o ```localhost:porta/Home/Index``` é o caminho inicial.

# Telas
* Geral: Todas as telas tem o cabeçalho com acessos às telas: Index (inicial), Create (Cadastro) e Read (Lista de hoteis). Com exceção da tela inicial, as demais telas tem o botão para retornar ou para a tela inicial ou para a tela de listagem.

* Index:![image](https://user-images.githubusercontent.com/47607259/131123021-9a4acf09-d873-4939-9f87-b7e4e2ba3063.png)
Acessível através de ```localhost:porta```, ```localhost:porta/Home``` e ```localhost:porta/Home/Index```.
Página inicial com breve detalhe do site e acesso às telas de Cadastro e Listas, tanto nos botões no Header como nos listados abaixo da respectiva descrição.

* Create:![image](https://user-images.githubusercontent.com/47607259/131123331-abfe4a07-dde6-4eec-a581-58826a406e03.png)
Acessível através de ```localhost:porta/Home/Create```.
Página de cadastro do Hotel. Há validações para todos os campos serem digitados. Eu tinha deixado os campos Complemento e Comodidades para aceitar strings vazias, mas sempre dava Exception quando as duas estavam vazias, mesmo tendo validação para mudar a string vazia para um hífen ("-"). A função ```ValidateInput(params``` é redundante e precisa ser revisada, pois tentei colocar a maioria direto no Front. Estava na transição de coloca-los direto no Model ```Hotel.cs```, tais como os ```[Display(Name = "Nome")]```. Demais seriam os ranges, mínimos e máximos (para Avaliação) e números para o CEP e Required para todos os campos.

* Read:![image](https://user-images.githubusercontent.com/47607259/131124736-69c57cc6-0d3f-4c84-b6cf-e9c01a489c08.png)
Acessível através de ```localhost:porta/Home/Read``.
Lista todos os hoteis cadastrados e seus campos. Dentro de cada lista é possível Editar ou Excluir (botões à direita).
Há dois filtros de pesquisa: Nome do Hotel e Comodidades. A ideia era colocar somente um botão, com funcionalidade para ambos. A pesquisa é efetuada de acordo com cada campo preenchido, independentemente. Se estiver vazio, considera todos para o respectivo campo.

* Update:![image](https://user-images.githubusercontent.com/47607259/131125113-0b60e4ef-3fb2-4813-95fa-df375a346462.png)
Acessível através de ```localhost:porta/Home/Update?HotelID=NUMERO``` onde NUMERO é o ID do Hotel (HotelID) ou clicando em Alterar, na listagem dos hoteis (Read).
Carrega o hotel selecionado/clicado e seleciona os dados de acordo com o respectivo Hotel para edição. Há validações iguais as da tela de cadastro.

* Delete: ![image](https://user-images.githubusercontent.com/47607259/131125454-9c19b6d5-dc2a-4f68-add0-357083cb28a3.png)
Acessível através de ```localhost:porta/Home/Delete?HotelID=NUMERO``` onde NUMERO é o ID do Hotel (HotelID) ou clicando em Excluir, na listagem dos hoteis (Read).
Carrega o hotel selecionado/clicado e confirma se o usuário realmente deseja excluir este hotel.


# Melhorias

* Redundância no Front referente às validações e atributos do HTML, tais como ```min```, ```max```,  ```required```, entre outros;
* Tradução de algumas validações e botões;
* Botão "Início" em ```Home/Create``` está equivocado: deveria estar como "Lista de Hoteis";
* Apenas um botão "Buscar" na tela da lista de hoteis;
* Disponibilizar as comodidades na tela de Edição;
* Na tela Delete: informar o nome do hotel para maior segurança na exclusão do hotel selecionado (a ideia princial é adicionar o seguinte código: ``` if (confirm('Confirma exclusão do hotel: ' + nomeHotel + '? Esta ação não poderá ser desfeita.')) == true { deleteHotel(); }```, mas preciso estudar como validar o Controller por JavaScript.
