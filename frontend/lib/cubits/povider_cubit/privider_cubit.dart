import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:frontend/cubits/povider_cubit/provider_state.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';


class ProviderCubit extends Cubit<ProviderState> {
  final String host;

  ProviderCubit({required this.host}) : super(ProviderState());

  Future<void> getProvider(String providerId) async {
    emit(ProviderState(loading: true));
    try {
      var url = Uri.parse('$host/Provider/$providerId');
      var response = await http.get(url);

      if (response.statusCode == 200) {
        var provider = jsonDecode(response.body);
        emit(ProviderState(provider: provider));
      } else {
        emit(ProviderState(error: 'Failed to load provider'));
      }
    } catch (e) {
      emit(ProviderState(error: e.toString()));
    } finally {
      emit(ProviderState(loading: false));
    }
  }

  Future<void> addProvider(String providerId, Map<String, dynamic> providerData) async {
    emit(ProviderState(loading: true));
    try {
      var url = Uri.parse('$host/Provider/add/$providerId');
      var response = await http.post(
        url,
        body: jsonEncode(providerData),
        headers: {'Content-Type': 'application/json'},
      );

      if (response.statusCode == 200) {
        emit(ProviderState());
      } else {
        emit(ProviderState(error: 'Failed to add provider'));
      }
    } catch (e) {
      emit(ProviderState(error: e.toString()));
    } finally {
      emit(ProviderState(loading: false));
    }
  }

  Future<void> editProvider(String providerId, Map<String, dynamic> updatedData) async {
    emit(ProviderState(loading: true));
    try {
      var url = Uri.parse('$host/Provider/edit/$providerId');
      var response = await http.put(
        url,
        body: jsonEncode(updatedData),
        headers: {'Content-Type': 'application/json'},
      );

      if (response.statusCode == 200) {
        emit(ProviderState());
      } else {
        emit(ProviderState(error: 'Failed to update provider data'));
      }
    } catch (e) {
      emit(ProviderState(error: e.toString()));
    } finally {
      emit(ProviderState(loading: false));
    }
  }

  Future<void> deleteProvider(String providerId) async {
    emit(ProviderState(loading: true));
    try {
      var url = Uri.parse('$host/Provider/delete/$providerId');
      var response = await http.delete(url);

      if (response.statusCode == 200) {
        emit(ProviderState());
      } else {
        emit(ProviderState(error: 'Failed to delete provider'));
      }
    } catch (e) {
      emit(ProviderState(error: e.toString()));
    } finally {
      emit(ProviderState(loading: false));
    }
  }
}
