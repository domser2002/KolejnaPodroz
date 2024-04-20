import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:frontend/cubits/user_ticket_cubit.dart/user_ticket_state.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';


class TicketCubit extends Cubit<TicketState> {
  TicketCubit() : super(TicketState());
  final host = 'https://localhost:7006';
 
  Future<void> getTicketById(String ticketId) async {
    emit(TicketState(loading: true));
    try {
      var url = Uri.parse('$host/Ticket/$ticketId');
      var response = await http.get(url);

      if (response.statusCode == 200) {
        var ticket = jsonDecode(response.body);
        emit(TicketState(ticket: ticket));
      } else {
        emit(TicketState(error: 'Failed to load ticket'));
      }
    } catch (e) {
      emit(TicketState(error: e.toString()));
    } finally {
      emit(TicketState(loading: false));
    }
  }


  Future<void> getTicketsByUser(String userId) async {
    emit(TicketState(loading: true));
    try {
      var url = Uri.parse('$host/Ticket/byUser/$userId');
      var response = await http.get(url);

      if (response.statusCode == 200) {
        var tickets = jsonDecode(response.body);
        emit(TicketState(tickets: tickets));
      } else {
        emit(TicketState(error: 'Nie udało się pobrać biletów użytkownika'));
      }
    } catch (e) {
      emit(TicketState(error: e.toString()));
    } finally {
      emit(TicketState(loading: false));
    }
  }

  
  Future<void> createTicket(Map<String, dynamic> ticketData) async {
    emit(TicketState(loading: true));
    try {
      var url = Uri.parse('$host/Ticket/create');
      var response = await http.post(url, body: jsonEncode(ticketData), headers: {
        'Content-Type': 'application/json'
      });

      if (response.statusCode == 201) {
        var ticket = jsonDecode(response.body);
        emit(TicketState(ticket: ticket));
      } else {
        emit(TicketState(error: 'Nie udało się utworzyć biletu'));
      }
    } catch (e) {
      emit(TicketState(error: e.toString()));
    } finally {
      emit(TicketState(loading: false));
    }
  }

 
  Future<void> editTicket(String ticketId, Map<String, dynamic> updatedData) async {
    emit(TicketState(loading: true));
    try {
      var url = Uri.parse('$host/Ticket/edit');
      var response = await http.put(url, body: jsonEncode(updatedData), headers: {
        'Content-Type': 'application/json'
      });

      if (response.statusCode == 200) {
        emit(TicketState());
      } else {
        emit(TicketState(error: 'Nie udało się edytować biletu'));
      }
    } catch (e) {
      emit(TicketState(error: e.toString()));
    } finally {
      emit(TicketState(loading: false));
    }
  }


  Future<void> deleteTicket(String ticketId) async {
    emit(TicketState(loading: true));
    try {
      var url = Uri.parse('$host/Ticket/delete/$ticketId');
      var response = await http.delete(url);

      if (response.statusCode == 200) {
        emit(TicketState());
      } else {
        emit(TicketState(error: 'Nie udało się usunąć biletu'));
      }
    } catch (e) {
      emit(TicketState(error: e.toString()));
    } finally {
      emit(TicketState(loading: false));
    }
  }
}
