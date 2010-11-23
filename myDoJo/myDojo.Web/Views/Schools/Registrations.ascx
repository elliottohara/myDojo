<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<MyDojo.Query.ViewModels.Dojos.StudentRegistrationView>>" %>
<ul>
    <%foreach (var registration in Model)
      {%>
      <li><%=Html.DisplayFor(m => registration.StudentName) %></li>
    <%
      }%>
</ul>
