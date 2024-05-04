import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:frontend/cubits/complaints_cubit/complaints_state.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';


class ComplaintsCubit extends Cubit<ComplaintState> {
  final String host;
  
  ComplaintsCubit({required this.host}) : super(ComplaintState());

  Future<void> makeComplaint(Map<String, dynamic> complaintData) async {
    emit(ComplaintState(loading: true));
    try {
      var url = Uri.parse('$host/Complaint/make');
      var response = await http.post(
        url,
        body: jsonEncode(complaintData),
        headers: {'Content-Type': 'application/json'},
      );

      if (response.statusCode == 200) {
        var complaint = jsonDecode(response.body);
        emit(ComplaintState(complaint: complaint));
      } else {
        emit(ComplaintState(error: 'Failed to make complaint'));
      }
    } catch (e) {
      emit(ComplaintState(error: e.toString()));
    } finally {
      emit(ComplaintState(loading: false));
    }
  }

  Future<void> removeComplaint(String complaintId) async {
    emit(ComplaintState(loading: true));
    try {
      var url = Uri.parse('$host/Complaint/remove/$complaintId');
      var response = await http.delete(url);

      if (response.statusCode == 200) {
        emit(ComplaintState());
      } else {
        emit(ComplaintState(error: 'Failed to remove complaint'));
      }
    } catch (e) {
      emit(ComplaintState(error: e.toString()));
    } finally {
      emit(ComplaintState(loading: false));
    }
  }

  Future<void> editComplaint(String complaintId, Map<String, dynamic> updatedData) async {
    emit(ComplaintState(loading: true));
    try {
      var url = Uri.parse('$host/Complaint/edit/$complaintId');
      var response = await http.patch(
        url,
        body: jsonEncode(updatedData),
        headers: {'Content-Type': 'application/json'},
      );

      if (response.statusCode == 200) {
        emit(ComplaintState());
      } else {
        emit(ComplaintState(error: 'Failed to edit complaint'));
      }
    } catch (e) {
      emit(ComplaintState(error: e.toString()));
    } finally {
      emit(ComplaintState(loading: false));
    }
  }

  Future<void> getComplaint(String complaintId) async {
    emit(ComplaintState(loading: true));
    try {
      var url = Uri.parse('$host/Complaint/get/$complaintId');
      var response = await http.get(url);

      if (response.statusCode == 200) {
        var complaint = jsonDecode(response.body);
        emit(ComplaintState(complaint: complaint));
      } else {
        emit(ComplaintState(error: 'Failed to load complaint'));
      }
    } catch (e) {
      emit(ComplaintState(error: e.toString()));
    } finally {
      emit(ComplaintState(loading: false));
    }
  }

  Future<void> getComplaintsByUser(String userId) async {
    emit(ComplaintState(loading: true));
    try {
      var url = Uri.parse('$host/Complaint/getByUser/$userId');
      var response = await http.get(url);

      if (response.statusCode == 200) {
        List<dynamic> complaints = jsonDecode(response.body);
        emit(ComplaintState(complaints: complaints));
      } else {
        emit(ComplaintState(error: 'Failed to load complaints'));
      }
    } catch (e) {
      emit(ComplaintState(error: e.toString()));
    } finally {
      emit(ComplaintState(loading: false));
    }
  }
}
