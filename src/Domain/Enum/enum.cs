//fiz esses enums para facilitar a comunicação entre as camadas.

namespace Domain.Enums;
public enum UserType {ADM, CLIENTE}

public enum StageAccount {Active, Inactive, Blocked}

public enum StatusOrder {Sending, Pending, Canceled}

public enum StageProduct {OutOfStock, InStock, SoldOu}